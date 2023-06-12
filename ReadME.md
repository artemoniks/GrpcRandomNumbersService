### Build docker image

*docker client must be run*

Run at the root path of the project:

        docker build -t grpcrandomnumbersserver:1.0 ./

### Run container

Then run the container:

        docker run -p 8080:8080/tcp grpcrandomnumbersserver:1.0 
