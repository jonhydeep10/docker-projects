# Elegir la imagen base asi como la version
FROM nginx:latest

# Definir el directorio de trabajo donde se colocara el sitio a desplegar
WORKDIR /usr/share/nginx/html

# Copiar la pagina html dentro del directorio de trabajo: <origen> <destino>, el . es para indicar que es el
# directorio de trabajo previamente definido
COPY ./src .

# Indicar el puerto por el que se visualizara la app, en este caso es el puerto del contenedor, habra que mapearlo con 
# el puerto del equipo fisico al ejecutar la creación del contenedor
EXPOSE 80