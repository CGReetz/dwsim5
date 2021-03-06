function [f Z EoS] = fugF(EoS,T,P,mix,phase,varargin)
%Calculates the fugacity and compressibility coefficient of mixture mix at temperature T
%and pressure P using Patel-Teja EoS
%
%Parameters:
%EoS: Equation of state used for calculations
%T: Temperature(K)
%P: Pressure (K)
%mix: cMixture object
%phase: set phase = 'liq' to calculate the fugacity of a liquid phase or
%   phase = 'gas' to calculate the fugacity of a gas phase
%
%Results:
%f: fugacity coefficient
%Z: compressibility coefficient 
%EoS: returns EoS used for calculations
%
%Reference: Patel and Teja, Chem. Eng. Sci. 37 (1982) 463-473

%Copyright (c) 2011 �ngel Mart�n, University of Valladolid (Spain)
%This program is free software: you can redistribute it and/or modify
%it under the terms of the GNU General Public License as published by
%the Free Software Foundation, either version 3 of the License, or
%(at your option) any later version.
%This program is distributed in the hope that it will be useful,
%but WITHOUT ANY WARRANTY; without even the implied warranty of
%MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
%GNU General Public License for more details.
%You should have received a copy of the GNU General Public License
%along with this program.  If not, see <http://www.gnu.org/licenses/>.


%************************************************
%Calculates the compressibility coefficient
%************************************************
R = 8.31; %Ideal gas constant, J/mol K

%Reads pure component properties and interaction coefficients
numC = mix.numC;
comp = mix.comp;
x = mix.x;
Tc = zeros(numC,1);
Pc = zeros(numC,1);
Zc = zeros(numC,1);
for i = 1:numC
    Tc(i) = comp(i).Tc;
    Pc(i) = comp(i).Pc;
    Zc(i) = comp(i).EoSParam(1);
    FPT(i) = mix.comp(i).EoSParam(2);
end
k1 = mix.k1;
k2 = mix.k2;
k3 = mix.k3;

%Reduced variables
Tr = zeros(numC,1);
Pr = zeros(numC,1);
for i = 1:numC
   Tr(i) = T/Tc(i);
   Pr(i) = P/Pc(i);
end

%Pure component parameters
a = zeros(numC,1);
b = zeros(numC,1);
c = zeros(numC,1);
Bi = zeros(numC,1);
for i = 1:numC
   [alfa, Omega_a, Omega_b, Omega_c] = alpha_function(EoS,mix,T);
   a(i) = Omega_a(i)*(R*Tc(i))^2/Pc(i)*alfa(i); %Eq. 5 of reference
   b(i) = Omega_b(i)*R*Tc(i)/Pc(i); %Eq. 6 of reference
   c(i) = Omega_c(i)*R*Tc(i)/Pc(i); %Eq. 7 of reference
   Bi(i) = b(i)*P/(R*T);
end

%Mixing rules
aij = zeros(numC,numC);
bij = zeros(numC,numC);
cij = zeros(numC,numC);
for i = 1:numC
   for j = 1:numC      
      aij(i,j) = sqrt(a(i)*a(j))*(1-k1(i,j)); %Eq. 25 of reference
      bij(i,j) = (b(i) + b(j))*(1-k2(i,j))/2;
      cij(i,j) = (c(i) + c(j))*(1-k3(i,j))/2;     
   end
end

%Mixture parameters
am = 0;
bm = 0;
cm = 0;
for i = 1:numC
   for j = 1:numC
      am = am + x(i)*x(j)*aij(i,j); %Eq. 22 of reference
      bm = bm + x(i)*x(j)*bij(i,j); %Eq. 23 of reference
      cm = cm + x(i)*x(j)*cij(i,j); %Eq. 24 of reference
   end
end
A = am*P/(R*T)^2;
B = bm*P/(R*T);
C = cm*P/(R*T);

%Compressibility coefficient calculation, resolution of cubic equation
coef1 = 1;
coef2 = (C - 1);
coef3 = (-2*B*C - B^2 - B - C + A);
coef4 = (B^2*C + B*C - A*B);

Z = roots([coef1 coef2 coef3 coef4]);

%Removes complex and negative roots
ZR = [];
for i = 1:3
   if isreal(Z(i)) && Z(i) > 0
   	ZR = [ZR Z(i)];   
   end
end

%Selects the coefficient corresponding to liquid (smallest positive root) or gas
%(largest root) phases
if strcmp(phase,'liq') == 1
    Z = min(ZR);   
elseif strcmp(phase,'gas') == 1
    Z = max(ZR);
else
    error(['The value "' phase '" of "phase" parameter is incorrect']);
end


%************************************************
%Calculates the fugacity coefficient
%************************************************
f = zeros(mix.numC,1);
for comp = 1:numC %Appendix of reference
    V = Z*R*T/P; % molar volume [m3/mol] 
    d = (bm*cm + 0.25*((bm+cm)^2))^0.5;
    Q = V + (bm+cm)/2; 
    sumxaij = 0;
    for j = 1:mix.numC
       sumxaij = sumxaij + x(j)*aij(comp,j);   
    end

    AA= -log(Z-B);
    AB= b(comp)/(V-bm);

    AC1 = -sumxaij/d*log((Q+d)/(Q-d));
    AC2 = (am*(b(comp)+c(comp))/(2*(Q^2 -d^2)));
    AC3 = am/(8*(d^3))*(c(comp)*(3*bm+cm)+ b(comp)*(3*cm+bm));
    AC4 = log((Q+d)/(Q-d)) - (2*Q*d)/(Q^2-d^2);
    AC= (AC1 + AC2 + AC3*AC4);

    f(comp) = exp(AA+AB+AC/(R*T));
end