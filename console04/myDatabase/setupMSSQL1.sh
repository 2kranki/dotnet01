#!/usr/bin/env bash


rm -fr .DS_Store

sudo docker rm -f mssql1

sudo docker pull mcr.microsoft.com/mssql/server:2017-latest

# Run mssql1 the first time using host port 1401
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Passw0rd!' \
   -p 1401:1433 --name mssql1 \
   -d mcr.microsoft.com/mssql/server:2017-latest

# Copy the directory, ./dockerBuild/install, into mssql1 as /install
sudo docker cp ./dockerBuild/rw mssql1:/

# Install VI.
sudo docker exec -it mssql1 "/rw/setup.sh"

# Install TSQLV4.
sudo docker cp ~/git/TSQLV4.mod.sql.txt mssql1:/rw/
sudo docker exec -it mssql1 "/rw/tsqlLoad.sh"

# Install TeachSQL.
sudo docker cp ~/git/create.sql.txt mssql1:/rw/
sudo docker exec -it mssql1 "/rw/teachLoad.sh"

# Install my sample SQL.
sudo docker exec -it mssql1 "/rw/load.sh"

