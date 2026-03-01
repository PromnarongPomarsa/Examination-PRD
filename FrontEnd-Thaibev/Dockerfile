# Build Stage
FROM node:22-alpine as build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --configuration=production

# Production Stage
FROM nginx:alpine

COPY default.conf.template /etc/nginx/templates/default.conf.template
COPY --from=build /app/dist/thaibev-test/browser /usr/share/nginx/html

RUN ls -R /app/dist
EXPOSE 80