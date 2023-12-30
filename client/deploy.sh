#!/bin/bash

# Set variables
REMOTE_USER="joshbaugh"
REMOTE_HOST="165.227.213.165"
REMOTE_PATH="/var/www/BandBlend2/client"
SSH_KEY="C:\Users\joshb\.ssh\bandblend"
BACKEND_URL="http://bandblend.net"
NODE_ENV="production"
SUDO_PASSWORD="Lonewolf59x"  # Replace with your actual sudo password

echo "Switching to branch main"
git checkout main

echo "Building app"
REACT_APP_BASE_URL=$BACKEND_URL NODE_ENV=$NODE_ENV npm run build

# Check if the directory exists on the remote server
echo "$SUDO_PASSWORD" | sudo -S ssh -i "$SSH_KEY" $REMOTE_USER@$REMOTE_HOST "[ -d $REMOTE_PATH ]"

# If the directory does not exist, create it
if [ $? -ne 0 ]; then
    echo "$SUDO_PASSWORD" | sudo -S ssh -i "$SSH_KEY" $REMOTE_USER@$REMOTE_HOST "sudo mkdir -p $REMOTE_PATH && sudo chown $REMOTE_USER:$REMOTE_USER $REMOTE_PATH"
fi

echo "Deploying to server..."
echo "$SUDO_PASSWORD" | sudo -S scp -i "$SSH_KEY" -v -r ./build/* $REMOTE_USER@$REMOTE_HOST:$REMOTE_PATH

# Check if the copy operation was successful
if [ $? -eq 0 ]; then
    echo "Files were uploaded successfully!"
else
    echo "File upload failed!"
    exit 1
fi

echo "Script completed running!"
