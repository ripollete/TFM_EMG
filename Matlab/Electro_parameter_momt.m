function [ parametros, str_param, str_uni] = Electro_parameter_momt_v3( senyal,fs )
%UNTITLED11 Summary of this function goes here
%   Versión de Electro_parameter_v2 para TGM Ripoll
%   Se diferencia de la anterior porque devuelve un vector con las unidades

    str_param = []; % Para tener    las etiquetas siempre disponibles y saber que indice corresponde con qué parametro
    str_uni = []; % Para tener las unidades disponibles y saber que unidad corresponde a cada parámetro
    parametros = []; % Vector para acumular los parametros
    

    %% Enhanced Mean absolute value 1 (1)
 [EMAV] = jEMAV(senyal);
    parametros = [parametros; EMAV];
    str_param = [str_param "Enhanced Mean absolute value (EMAV)" ];   
    str_uni = [str_uni ""];
    
    %% Mean Absolute Value (MAV) 2 (3)
    [ MAV ] = jMAV( senyal ); 
    str_param = [str_param "Mean Absolute Value (MAV)"];        
    parametros = [parametros; MAV];
    str_uni = [str_uni ""];
    
    %% Root Mean Square (RMS) 3 (7)
    [ RMS ] = jRMS( senyal ); 
    str_param = [str_param "Root Mean Square (RMS)"];        
    parametros = [parametros; RMS];
    str_uni = [str_uni ""];
    
        %% Average Amplitude Change (AAC) 4 (8)
    [ AAC ] = jAAC( senyal );
    str_param = [str_param "Average Amplitude Change (AAC)"];        
    parametros = [parametros; AAC];
    str_uni = [str_uni ""];

           %% Difference Absolute Standard Deviation Value (DASDV) 5 (9)
    [ DASDV ] = jDASDV( senyal );
    str_param = [str_param "Difference Absolute Standard Deviation Value (DASDV)"];        
    parametros = [parametros; DASDV];
    str_uni = [str_uni ""];
    
%     %%  Log Detector (LD) 6 (10)
%     [ LD ] = jLD( senyal );
%     str_param = [str_param "Log Detector (LD)"];        
%     parametros = [parametros; LD];
%     str_uni = [str_uni "UI"];
%     
    %% Modified Mean Absolute Value 2 (MMAV) 6 (11)
    [ MMAV ] = jMMAV( senyal ); 
    str_param = [str_param "Modified Mean Absolute Value (MMAV)"];        
    parametros = [parametros; MMAV];
    str_uni = [str_uni ""];
    
%% Modified Mean Absolute Value  (MMAV2) 7 (12)
    [ MMAV2 ] = jMMAV2( senyal ); %13
    str_param = [str_param "Modified Mean Absolute Value 3 (MMAV2)"];        
    parametros = [parametros; MMAV2];
    str_uni = [str_uni ""];

    %% Variance of EMG (VAR) 8 (15)
    [ VAR ] = jVAR( senyal ); %13
    str_param = [str_param "Variance of EMG (VAR)"];        
    parametros = [parametros; VAR];
    str_uni = [str_uni ""]; 
    
    %%
    parametros = parametros';
    
 
end

 








