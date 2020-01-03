%%Configurar parametros
%%randsample(1000000,1)
%combinaciones = [[5;6],[5;7],[5;8],[5;9],[5;10],[5;11],[5;12],[6;7],[6;8],[6;9],[6;10],[6;11],[6;12],[7;8],[7;9],[7;10],[7;11],[7;12],[8;9],[8;10],[8;11],[8;12],[9;10],[9;11],[9;12],[10;11],[10;12],[11;12]];
%combinaciones =[ [5;6;7],[5;6;8],[5;6;9],[5;6;10],[5;6;11],[5;6;12],[5;7;8],[5;7;9],[5;7;10],[5;7;11],[5;7;12],[5;8;9],[5;8;10],[5;8;11],[5;8;12],[5;9;10],[5;9;11],[5;9;12],[5;10;11],[5;10;12],[5;11;12],[6;7;8],[6;7;9],[6;7;10],[6;7;11],[6;7;12],[6;8;9],[6;8;10],[6;8;11],[6;8;12],[6;9;10],[6;9;11],[6;9;12],[6;10;11],[6;10;12],[6;11;12],[7;8;9],[7;8;10],[7;8;11],[7;8;12],[7;9;10],[7;9;11],[7;9;12],[7;10;11],[7;10;12],[7;11;12],[8;9;10],[8;9;11],[8;9;12],[8;10;11],[8;10;12],[8;11;12],[9;10;11],[9;10;12],[9;11;12],[10;11;12]];

%%Combinaciones de 4
combinaciones = [];
for a=5:5
    for b=a+1:6
        for c=b+1:7
            for d=c+1:8
                for e=d+1:9
                    for f=e+1:10
                        for g = f+1:11
                            for h = g+1:12
                combinaciones = cat(2,combinaciones,[a;b;c;d;e;f;g;h]);
            end
        end
    end
    end
        end
    end
    end
end

[x,y] = size(combinaciones);
resultado_final = [];
for z=1:y
seed = 816225; % la primera vez utilice randsample 1000000 y salió ese valor que utilizaré de semilla para reproduccir el experimento
%%randsample(1000000,1)
seed_step = 981365; % lo ejecuto la primera vez y este será el step para la semilla cada vez que la utilizo
posicion_caracteristicas = [combinaciones(1,z) combinaciones(2,z) combinaciones(3,z) combinaciones(4,z) combinaciones(5,z) combinaciones(6,z) combinaciones(7,z) combinaciones(8,z)]; %5:12  8:9
iteraciones = 250;
pvalidacion = 0.20;
ptest = 0.30;
ptrain = 0.70;

datas_ = datas_A;
tamanyo = size(datas_,1);
%%Separamos las muestras para el test final y las almacenamos en ptestf
rng(seed);
validacion = randsample(tamanyo,floor(tamanyo*pvalidacion));
datas_validacion = datas_(validacion,:);
datas_train_test =datas_;
datas_train_test(validacion,:) = [];

%%hacemos un for para guardar en cada iteración que datos utilizaremos de
%%test y cuales para train
tamanyo_train_test = size(datas_train_test,1);
datas_train_rows = [];
datas_confusion = [];
matriz_resultados = [];
matriz_resultados_juntos = [];
coeffs = [];
for i=1:iteraciones 
    %%Separo los datos
    seed = seed + seed_step;
    rng(seed);
    datas_train_rows_ = randsample(tamanyo_train_test,floor(tamanyo_train_test*ptrain));
    %%Preparo los datos para pasarlos por la función fitcdiscr y obtener el
    %%modelo
    data_train = datas_train_test(datas_train_rows_,posicion_caracteristicas); %%% 5:12
    tipo = datas_train_test(datas_train_rows_,1);
    Mdl = fitcdiscr(data_train,tipo);
    AUC_aux = 0;
    
    %TEST 1 con los datos de train
    result_predict = predict(Mdl,data_train);
    con = confusionmat(table2array(tipo(:,1)),result_predict);
    TP = con(1,1);
    FP = con(1,2);
    FN = con(2,1);
    TN = con(2,2);
    [parametros, aux] = confusion_matrix_features(TP,TN,FN,FP);
    parametros = [i;1;parametros];
    matriz_resultados = cat(2,matriz_resultados,parametros);
    AUC_aux = AUC_aux + parametros(15);
    
    %TEST 2 con los datos test
    %Preparo los datos para test y utilizarlo con predict
    data_test = datas_train_test;
    data_test(datas_train_rows_,:) = [];
    tipo_test = table2array(data_test(:,1));
    data_test = data_test(:,posicion_caracteristicas);  %%%%5:12
    
    result_predict = predict(Mdl,data_test);
    con = confusionmat(tipo_test,result_predict);
    TP = con(1,1);
    FP = con(1,2);
    FN = con(2,1);
    TN = con(2,2);
    [parametros, aux] = confusion_matrix_features(TP,TN,FN,FP);
    parametros = [i;2;parametros];
    matriz_resultados = cat(2,matriz_resultados,parametros);
    AUC_aux = AUC_aux + parametros(15);
    
    %TEST 3 con los datos de validación
    data_test = datas_validacion;
    tipo_test = table2array(data_test(:,1));
    data_test = data_test(:,posicion_caracteristicas);
    result_predict = predict(Mdl,data_test);
    con = confusionmat(tipo_test,result_predict);
    TP = con(1,1);
    FP = con(1,2);
    FN = con(2,1);
    TN = con(2,2);
    [parametros, aux] = confusion_matrix_features(TP,TN,FN,FP);
    parametros = [i;3;parametros];
    matriz_resultados = cat(2,matriz_resultados,parametros);
    AUC_aux = AUC_aux + parametros(15);
    
    %%Coeficientes
    coeffs = cat(2,coeffs,[Mdl.Coeffs(1,2).Linear;Mdl.Coeffs(1,2).Const]);
    
    %%AUC media conjunta 3 test
    matriz_resultados_juntos = cat(2,matriz_resultados_juntos,[i;AUC_aux/3.0]);
    
    %%resultado final
    
    %% confusionchart(tipo_test,result_predict);
    %%csvwrite('res_aux1.csv',table2array(data_test))
    %%csvwrite('res_aux.csv',data_test)
    %%datas_train_rows = cat(2,datas_train_rows,datas_train_rows_);
end

mean(matriz_resultados(15,:));
std(matriz_resultados(15,:));
resultado_final= cat(2,resultado_final,[combinaciones(1,z);combinaciones(2,z);combinaciones(3,z);combinaciones(4,z);combinaciones(5,z);combinaciones(6,z);combinaciones(7,z);combinaciones(8,z);mean(matriz_resultados(15,:));std(matriz_resultados(15,:))]);
max(resultado_final(3,:));
%Ordenar
[values,I] = sort(matriz_resultados_juntos(2,:),'descend');
IBest = sort(I(1:9));

% data_test = 
%  a=table2array(datas_A(:,7:17))
%  tipo = table2array(datas_A(:,1))
%  
%  Mdl = fitcdiscr(a,tipo)

%%
%Pruebas selección automática
% Md11=fitcdiscr(data_train,tipo);
% data_train= table2array(data_train);
% data_test = table2array(data_test);
% tipo = table2array(tipo)
% func = @(data_train, tipo, data_test, tipo_test) sum(tipo_test ~= predict(fitcdiscr(data_train,tipo),data_test));
% opts = statset('display','iter');
% learnt = sequentialfs(func,data_train,tipo,'options',opts)
% 
% 
% Md11=fitcdiscr(xtrain,ytrain);
% func = @(xtrain, ytrain, xtest, ytest) sum(ytest ~= predict(Md1,xtest));
% >> learnt = sequentialfs(func,xtrain,ytrain)
end