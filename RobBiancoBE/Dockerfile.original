FROM mcr.microsoft.com/dotnet/aspnet:8.0

RUN apt-get update && apt-get install -y git openssh-client && rm -rf /var/lib/apt/lists/*

WORKDIR /app

# Copia lo script e la chiave SSH
COPY entrypoint.sh /entrypoint.sh
COPY ssh /app/ssh
RUN chmod +x /entrypoint.sh && chmod 600 /app/ssh/id_ed25519

ENTRYPOINT ["/entrypoint.sh"]
