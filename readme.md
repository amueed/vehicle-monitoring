<!-- GETTING STARTED -->

## Project Technologies

### Front End

- React with Vite
- Material UI

### Back End

- .net core
- Minimal API
- EF Core
- Swagger

## Running this Project

### Prerequisites

Before running this project, you need to install following:

- [Docker](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/downloads)
- [Visual Studio Code](https://code.visualstudio.com/download)

### How to Run

1. Clone the repo or Extract from zip file.
   ```sh
   git clone https://github.com/amueed/vehicle-monitoring.git
   ```
2. Open Terminal Window in VS Code 'Terminal > New Terminal' and run this command in terminal.
   ```sh
   docker-compose up --build -d
   ```
3. After successful build of docker images in compose file, all the services will start running.

4. Browse Front-end App at http://localhost:4200 and Backend app at http://localhost:8080/swagger/index.html
