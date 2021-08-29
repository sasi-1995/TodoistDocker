# syntax=docker/dockerfile:1
FROM ubuntu:20.04
RUN apt-get update &&\
    apt-get install -y wget
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb
RUN apt update && \
  apt install -y apt-transport-https && \
  apt update && \
  apt install -y dotnet-sdk-5.0

RUN dotnet tool install --global dotnet-ef

WORKDIR /app
COPY Todoist .
RUN dotnet restore
EXPOSE 5000/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh