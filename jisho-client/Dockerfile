FROM node:18.20 as build
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:alpine
COPY --from=build /app/dist/jisho-client/browser /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
