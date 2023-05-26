FROM node:18.16.0 as node
WORKDIR /app
COPY . .
RUN npm install -g npm
RUN npm install
RUN npm run build --omit=dev

FROM docker.io/nginx:alpine-slim
COPY --from=node /app/dist/tasks-app.ui /usr/share/nginx/html