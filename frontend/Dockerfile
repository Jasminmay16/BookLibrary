FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY frontend/frontend.csproj frontend/
COPY Shared/Shared.csproj Shared/
RUN dotnet restore frontend/frontend.csproj

COPY frontend/. frontend/
COPY Shared/. Shared/
RUN dotnet publish frontend/frontend.csproj -c Release -o /app/publish

FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY frontend/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
