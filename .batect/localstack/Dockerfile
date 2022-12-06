FROM localstack/localstack:latest

COPY ./.batect/localstack/dynamodb/ /dynamodb/
COPY ./.batect/localstack/init.sh /docker-entrypoint-initaws.d/init.sh
