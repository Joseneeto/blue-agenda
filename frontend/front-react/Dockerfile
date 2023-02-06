FROM node:12-slim AS build
 
WORKDIR /usr/app
 
COPY package*.json ./
 
RUN npm install
 
COPY . . 
 
RUN npm run build

FROM nginx:1.17.6-alpine
COPY --from=build /usr/app/build/ /usr/share/nginx/html/

CMD [ "nginx", "-g", "daemon off;"]