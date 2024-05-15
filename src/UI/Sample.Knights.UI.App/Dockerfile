FROM node:latest
RUN npm install -g http-server

WORKDIR /usr/src/app

COPY package.json ./
COPY package-lock.json ./

RUN npm install
COPY . .

RUN npm run build
EXPOSE 8080
CMD [ "http-server", "dist" ]