#Autor: Javier Ripoll Esteve
#Correo: ripollete@hotmail.com
#Fecha 01/12/2019

dir_origen <-"C:\Mi_ruta"
archivo_csv <-"MiArchivo.csv"
dir_destino <-"C:/Mi_destino"

setwd(dir_origen)

library(readr)
datosCrudos <- read_delim(archivo_csv, ";", 
                      escape_double = FALSE, col_names = FALSE, 
                      trim_ws = TRUE)

datosCrudos$X4[datosCrudos$X4 == 1]<-'A'
datosCrudos$X4[datosCrudos$X4 == 2]<-'B'
id_samples <- unique(datosCrudos$X3)

setwd(dir_destino)

#Creo los directorios A y B si no existen
directorioA<-paste(dir_destino,'\\A')
if(!file.exists(directorioA))
{
  mainDir<- dir_destino
  dir.create(file.path(mainDir, 'A'))
}

directorioB<-paste(dir_destino,'\\B')
if(!file.exists(directorioB))
{
  mainDir<- dir_destino
  dir.create(file.path(mainDir, 'B'))
}

for (val in id_samples) {
  id_sample <-val
  signaltipo <- (subset(datosCrudos,X3==id_sample)$X4)[1]
  patient <- (subset(datosCrudos,X3== id_sample)$X2)[1]
  exportdata<-subset(datosCrudos,X3== id_sample)$X1
  
  directorio<- paste(dir_destino,'\\',signaltipo,'\\',patient+10000,sep='')
  if(!file.exists(directorio))
  {
    mainDir<- paste(dir_destino,'\\',signaltipo,sep='')
    dir.create(file.path(mainDir, patient+10000))
  }
  
  
  filename <-paste(patient+10000,'_',signaltipo,'_',id_sample,'.csv',sep='')
  ruta <- paste(directorio,'\\',filename,sep = '')
  
  
  write.table(exportdata,ruta,row.names = FALSE,col.names = FALSE)
}
