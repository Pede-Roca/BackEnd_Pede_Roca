# BackEnd_Pede_Roca

comando para buildar o docker:
docker build --no-cache -t pederoca-backend .

comando para execultar a imagem:
docker run -d -p 8000:80 --name pederoca-backend pederoca-backend