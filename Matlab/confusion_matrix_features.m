function [parametros, str_param] = confusion_matrix_features(TP_,TN_,FN_,FP_)
str_param = []; % Para tener las etiquetas siempre disponibles y saber que indice corresponde con qué parametro
parametros = []; % Vector para acumular los parametros

parametros = [TP_;TN_;FN_;FP_];
str_param = ["TP";"TN";"FN";"FP"];

%Sensibilidad
TPR_ = TP_/(TP_+FN_);
parametros = [parametros; TPR_];
str_param = [str_param;"Sensibilidad"];

%Especificidad
TNR_ = TN_/(TN_+FP_);
parametros = [parametros; TNR_];
str_param = [str_param;"Especificidad"];

%Precision
PPV_ = TP_ / (TP_+FP_);
parametros = [parametros; PPV_];
str_param = [str_param;"Precisión"];

%valor predictivo negativo
NPV_ = TN_ / (TN_+FN_);
parametros = [parametros; NPV_];
str_param = [str_param;"Valor predictivo negativo"];

%tasa de fallos
FNR_ =1-TPR_;
parametros = [parametros; FNR_];
str_param = [str_param;"Tasa de fallos"];

%Tasa de falsos negativos
FPR_ = 1-TNR_;
parametros = [parametros; FPR_];
str_param = [str_param;"Tasa de falsos negativos"];

%Tasa de Descubrimientos Falsos FDR
FDR_ = 1-PPV_;
parametros = [parametros; FDR_];
str_param = [str_param;"Tasa de Descubrimientos Falsos"];

% Accuracy Exactitud
ACC_ = (TP_+TN_) / (TP_+TN_+FP_+FN_);
parametros = [parametros; ACC_];
str_param = [str_param;"Exactitud"];

% AUC
%%https://www.researchgate.net/post/Is_it_possible_to_calculate_area_under_ROC_curve_from_confusion_matrix_values
X_ = [0;TPR_;1];
Y_ = [0;FPR_;1];
AUC_ = trapz(Y_,X_); % AUC = 0.8926
parametros = [parametros; AUC_];
str_param = [str_param;"AUC"];
end