set -euo pipefail

LOCALSTACK_URL=${LOCALSTACK_URL:-http://localhost:4566}

aws dynamodb create-table \
    --endpoint-url "$LOCALSTACK_URL" \
    --cli-input-json file:///dynamodb/users-table.json \
    || echo "dynamodb table exists!"

aws dynamodb batch-write-item \
    --endpoint-url "$LOCALSTACK_URL" \
    --request-items file:///dynamodb/seed-users.json