#!/bin/bash

# Nome da aplicação
APP_NAME="ASIptvServer"

# Diretórios de instalação
APP_DIR="/var/lib/$APP_NAME"
DATA_DIR="$APP_DIR/data"
CACHE_DIR="/var/tmp/${APP_NAME}_cache"

# Arquivo do serviço systemd (se necessário)
SERVICE_FILE="/etc/systemd/system/$APP_NAME.service"

# Verificar se o script está sendo executado como root
if [ "$(id -u)" -ne 0 ]; then
  echo "Este script precisa ser executado como root."
  exit 1
fi

# Criar diretórios necessários
echo "Criando diretórios..."
mkdir -p "$APP_DIR" "$DATA_DIR" "$CACHE_DIR"
chmod 755 "$APP_DIR" "$DATA_DIR" "$CACHE_DIR"

# Copiar arquivos da aplicação para o diretório de instalação
echo "Copiando arquivos da aplicação..."
cp -r ./* "$APP_DIR/"
chmod +x "$APP_DIR/" # Tornar o binário executável

# Configurar o serviço systemd (se necessário)
if [ ! -f "$SERVICE_FILE" ]; then
  echo "Criando o serviço systemd..."
  cat > "$SERVICE_FILE" <<EOL
[Unit]
Description=$APP_NAME Service
After=network.target

[Service]
Type=simple
ExecStart=/usr/bin/dotnet $APP_DIR/ASIptvServer.dll
WorkingDirectory=$APP_DIR
Restart=on-failure
User=root

[Install]
WantedBy=multi-user.target
EOL
  systemctl daemon-reload
  systemctl enable "$APP_NAME"
fi

# Configurar permissões
echo "Configurando permissões..."
chown -R root:root "$APP_DIR" "$DATA_DIR" "$CACHE_DIR"

# Finalizar instalação
echo "Instalação concluída!"
echo "Você pode iniciar o serviço com: systemctl start $APP_NAME"
