#!/bin/bash

# Set variables
REMOTE_USER="joshbaugh"
REMOTE_HOST="45.55.38.71"
REMOTE_PATH="/var/www/BandBlend2/client"
SSH_KEY="C:\Users\joshb\.ssh\bandblend"
BACKEND_URL="http://45.55.38.71" # Change this to your back-end server's URL https for SSL
# WEBSOCKET_URL="wss://<URL>443" # Change this to your WebSocket server's URL 2ss for SSL
NODE_ENV="production"

echo "Switching to branch master"
git checkout master

echo "Building app"
REACT_APP_BASE_URL=$BACKEND_URL NODE_ENV=$NODE_ENV npm run build

# Check if the directory exists on the remote server
ssh -i "$SSH_KEY" $REMOTE_USER@$REMOTE_HOST "[ -d $REMOTE_PATH ]"

# If the directory does not exist, create it
if [ $? -ne 0 ]; then
ssh -i "$SSH_KEY" $REMOTE_USER@$REMOTE_HOST "sudo mkdir -p $REMOTE_PATH && sudo chown $REMOTE_USER:$REMOTE_USER $REMOTE_PATH"
fi

echo "Deploying to server..."
scp -i "$SSH_KEY" -v -r ./build/* $REMOTE_USER@$REMOTE_HOST:$REMOTE_PATH

# Check if the copy operation was successful
if [ $? -eq 0 ]; then
echo "Files were uploaded successfully!"
else
echo "File upload failed!"
exit 1
fi

echo "Script completed running!"