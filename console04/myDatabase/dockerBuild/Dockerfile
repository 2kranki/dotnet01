FROM microsoft/mssql-server-linux:2017-latest
LABEL maintainer="bob@2kranki.us"
ENV MSSQL_SA_PASSWORD="Passw0rd!"
ENV ACCEPT_EULA=Y
COPY . /
RUN apt-get update && apt-get install -y vim
CMD [ "/opt/mssql/bin/sqlservr" ]
