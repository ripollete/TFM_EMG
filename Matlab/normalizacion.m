function norm = normalizacion_v1(datas_)
    norm =[];
    datas_= table2array(datas_);
    max_norm = max(datas_);
    min_norm = min(datas_);
    for i = 1:size(datas_,1)
        x = datas_(i);
        norm(i) = (x - min_norm) / (max_norm - min_norm);
    end
    norm = table(transpose (norm));
end

%%datas_ = datas_A(:,8);
