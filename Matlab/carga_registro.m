function datasCrudo = carga_registro_v4(numPac)
%Esta función introduciendo el código del individuo dibuja toda la señal y
%por tramos de 5 segundos
%   
datasCrudo = [];
path_in = ['C:\Users\ripol\OneDrive\Master UOC\TFG\Projecte\Registros\A\' num2str(numPac)];
files = dir(path_in);

nfiles = length(files);

    for i = 3:1:nfiles
        nameFich = files(i).name;
        [num2str(nfiles - 3) ' - ' num2str(i - 3) ' - ' nameFich]
        datasfichero = csvread([path_in '\' nameFich]);
        datasCrudo = [datasCrudo datasfichero(:,1)];    
    end
fm = 1024;
t_emg = 1/fm:1/fm:length(datasCrudo)/fm;


for i =1:1:10
    figure
    t_datas = (5*i):1/fm:((5*i)+5)-1/fm;
    t_datos = datasCrudo([5120*i:(5120*i)+5119],:);
    plot(t_datas,t_datos,'k');ylabel([{num2str(i)},{'mV'}]);xlabel('Time(s)')
    propertyeditor('on')
    addToolbarExplorationButtons(gcf)
end
i= i+1;
t_emg = 1/fm:1/fm:length(datasCrudo)/fm;
figure
plot(t_emg,datasCrudo(:,1),'k');ylabel([{num2str(i)},{'V'}]);xlabel('Time(s)')
propertyeditor('on')
addToolbarExplorationButtons(gcf)

end

