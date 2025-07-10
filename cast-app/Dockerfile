# Use python's offical image
FROM python:3.11-slim

# Set the working directory inside the container
WORKDIR /app

# Copy python source code into the container
COPY app.py .

# Install required dependencies
RUN pip install flask redis

# Expose port where the app is listening inside the container
EXPOSE 8000

# Command to run the app
CMD ["python", "app.py"]
