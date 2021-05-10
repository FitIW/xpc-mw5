# Readme

## Prerequisites

- Installed Docker

## Build Docker Images

```shell
sudo docker build -t cookbook-web .
sudo docker build -t cookbook-api .
```

## Run Docker Containers

```shell
sudo docker run --rm -p 80:80 cookbook-web
sudo docker run --rm -p 80:80 cookbook-api
```

## Run Docker Compose

```shell
docker-compose -d up
```
