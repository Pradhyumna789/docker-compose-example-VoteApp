# docker-compose-example-VoteApp

## Architecture Overview   

<img width="1175" height="696" alt="Screenshot 2025-07-11 002744" src="https://github.com/user-attachments/assets/b6b35bfb-d85d-4d60-82e3-480a475937a1" />

## To spin up all the containers 
  - docker-compose up

## To restart 
  - docker-compose up (same command because docker will cache everything up to date)

## To delete docker volume storage and spin up containers afresh
  - docker compose down -v
  - docker system prune -af --volumes

