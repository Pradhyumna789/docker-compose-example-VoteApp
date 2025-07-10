# Building from the offical node.js image
FROM node:20-slim

# Set up working directory inside the container
WORKDIR /app

# Copy the source code into the container
COPY app.js .

# Install the necessary dependencies
RUN apt-get update && \
    apt-get install -y netcat-openbsd libpq-dev && \
    rm -rf /var/lib/apt/lists/* && \
    npm init -y && \
    npm install express pg


# Expose the port your app listens on from inside the container
EXPOSE 8081

# Command to run the app
CMD ["node", "app.js"]
