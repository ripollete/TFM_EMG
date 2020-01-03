function datas_crudo_senyal = extrae_senyal_v1(codigo_,inicio_,fin_,fs_)
%EXTRAE_SENYAL Summary of this function goes here
%   Detailed explanation goes here
path_in = ['C:\Users\ripol\OneDrive\Master UOC\TFG\Projecte\Registros\'];

File = dir(fullfile(path_in, '**', ['*_' num2str(codigo_) '.csv']));

datas_crudo_senyal = csvread([File.folder '\' File.name]);
datas_crudo_senyal = [datas_crudo_senyal(:,1)];
posini = round(fs_ *inicio_)+1;
posfin = round(fs_ *fin_)+1;
datas_crudo_senyal = datas_crudo_senyal([posini:posfin],:);
end

