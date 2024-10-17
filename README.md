# BackEnd_Pede_Roca

comando para buildar o docker:
docker build --no-cache -t pederoca-backend .

comando para execultar a imagem:
docker run --name pederoca-backend -d -p 8000:80 *nome da imagem*


---
docker tag pederoca-backend:latest phsantos616/api_pederoca_backend:dev

---
docker push phsantos616/api_pederoca_backend:dev