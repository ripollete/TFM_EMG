%% Modificación después de la reunión 26/11/2019
carga_segmentosPA;

%%Protocolo B %%
%%MA OBERTA%%
uno=datas_crudo_segmentos_PA(:,[2,3:4]);
uno.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
dos=datas_crudo_segmentos_PA(:,[2,7:8]);
dos.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
tres=datas_crudo_segmentos_PA(:,[2,11:12]);
tres.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
cuatro=datas_crudo_segmentos_PA(:,[2,15:16]);
cuatro.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
cinco=datas_crudo_segmentos_PA(:,[2,19:20]);
cinco.Properties.VariableNames([2 3]) = {'INI' 'FIN'};

datas_MO_A=[uno;dos;tres;cuatro;cinco];
[nRows,nCols] = size(datas_MO_A);
etiqueta = table(ones(nRows,1));
etiqueta.Properties.VariableNames([1]) = {'TIPO'};
datas_MO_A = [etiqueta datas_MO_A];

clear uno dos tres cuatro cinco etiqueta nRows nCols


%%Braç tancat%%
uno=datas_crudo_segmentos_PA(:,[2,5:6]);
uno.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
dos=datas_crudo_segmentos_PA(:,[2,9:10]);
dos.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
tres=datas_crudo_segmentos_PA(:,[2,13:14]);
tres.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
cuatro=datas_crudo_segmentos_PA(:,[2,17:18]);
cuatro.Properties.VariableNames([2 3]) = {'INI' 'FIN'};
cinco=datas_crudo_segmentos_PA(:,[2,21:22]);
cinco.Properties.VariableNames([2 3]) = {'INI' 'FIN'};

datas_AT_A=[uno;dos;tres;cuatro;cinco];
[nRows,nCols] = size(datas_AT_A);
etiqueta = table(2*ones(nRows,1));
etiqueta.Properties.VariableNames([1]) = {'TIPO'};
datas_AT_A = [etiqueta datas_AT_A];

clear uno dos tres cuatro cinco etiqueta nRows nCols

%%matriu A%%
datas_A = [datas_MO_A;datas_AT_A];
%%matriu final A netejant valors%%
datas_A = datas_A(find(datas_A.INI ~=0 &  datas_A.FIN ~=0),:);

clear datas_MO_B datas_MT_B datas_AT_B datas_crudo_segmentos_PA
%%
fs = 1024;
[nRows,nCols] = size(datas_A);
n_features = 8;
aux_features = NaN(nRows,1);


for i = 1:n_features
new_column = table(aux_features);
new_column.Properties.VariableNames([1]) = {['FEATURE_' num2str(i)]};
datas_A = [datas_A new_column];
end



for i=1:nRows
    codigo = datas_A(i,:).code;
    inicio = datas_A(i,:).INI;
    fin = datas_A(i,:).FIN;
    
    senyal = extrae_senyal(codigo, inicio, fin, fs);
    [ parametros, str_param, str_uni ] = Electro_parameter_momt( senyal,fs);
    datas_A(i,:).FEATURE_1 = parametros(:,1);
    datas_A(i,:).FEATURE_2 = parametros(:,2);
    datas_A(i,:).FEATURE_3 = parametros(:,3);
    datas_A(i,:).FEATURE_4 = parametros(:,4);
    datas_A(i,:).FEATURE_5 = parametros(:,5);
    datas_A(i,:).FEATURE_6 = parametros(:,6);
    datas_A(i,:).FEATURE_7 = parametros(:,7);
    datas_A(i,:).FEATURE_8 = parametros(:,8);
    
end

datas_A.Properties.VariableNames([5:(5+n_features-1)]) = str_param;

%%
%%Normalización
datas_norm_A = datas_A;
for i = 5:(5+n_features-1)
    datas_norm_A(:,i) = normalizacion(datas_A(:,i));
end

%%Boxplot NORM
datas_array_A = table2array(datas_norm_A);
tamanyo = length(datas_array_A);
%datas_AoxPlot = [datas_array_A(:,7);datas_array_A(:,8)]
datas_BoxPlot = [datas_array_A(:,5);datas_array_A(:,6);datas_array_A(:,7);datas_array_A(:,8);datas_array_A(:,9);datas_array_A(:,10);datas_array_A(:,11);datas_array_A(:,12)];
datas_label_feature = [repmat(datas_norm_A.Properties.VariableNames([5]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([6]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([7]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([8]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([9]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([10]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([11]),tamanyo,1);
    repmat(datas_norm_A.Properties.VariableNames([12]),tamanyo,1)
    ];

datas_label_group= [];
for i=1:n_features
    datas_label_group = [datas_label_group ;datas_array_A(:,1)];
end
for i = 1-1:n_features-1
    pos_ini= (i*tamanyo)+1;
    pos_fin = pos_ini + tamanyo-1;
    %datas_label_feature(pos_ini:pos_fin,1)
    subplot(5,3,i+1);boxplot(datas_BoxPlot(pos_ini:pos_fin,1), {datas_label_group(pos_ini:pos_fin,1)} ,'factorgap',10)
    title(datas_label_feature(pos_ini:pos_ini,1))
    ylabel(str_uni(1,i+1))
    if (min(datas_BoxPlot(pos_ini:pos_fin,1)) ~= max(datas_BoxPlot(pos_ini:pos_fin,1)))
        ylim([min(datas_BoxPlot(pos_ini:pos_fin,1)) max(datas_BoxPlot(pos_ini:pos_fin,1))])
    end
end
propertyeditor('on')
addToolbarExplorationButtons(gcf)
%clear codigo inicio fin senyal nRows nCols n_features aux_features i



