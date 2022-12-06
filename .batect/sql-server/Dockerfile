FROM mcr.microsoft.com/mssql/server:2019-latest

WORKDIR /src/.batect/sql-server

COPY ./Casino.Database.dacpac .
COPY ./SeedData ./SeedData

# Install Unzip
USER root
RUN apt-get update \
    && apt-get install unzip -y


run wget "https://security.debian.org/debian-security/pool/updates/main/o/openssl/libssl1.0.0_1.0.1t-1+deb8u12_amd64.deb" \
    && dpkg --ignore-depends=multiarch-support -i libssl1.0.0_1.0.1t-1+deb8u12_amd64.deb

# Install SQLPackage for Linux and make it executable
RUN wget -progress=bar:force -q -O sqlpackage.zip https://go.microsoft.com/fwlink/?linkid=2113331 \
    && unzip -qq sqlpackage.zip -d /opt/sqlpackage \
    && chmod +x /opt/sqlpackage/sqlpackage

# Add the DACPAC to the image
COPY ./Casino.Database.dacpac /tmp/db.dacpac

# Configure external build arguments to allow configurability.
ARG DBNAME=CasinoDatabase
ARG PASSWORD=YourS3cureP@ass

# Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_USER="sa"
ENV SA_PASSWORD=$PASSWORD

# this was breaking batect but will leave as a reference https://github.com/batect/batect/issues/1344
# HEALTHCHECK --interval=10s --timeout=3s --start-period=10s --retries=5 \
#     CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U $SA_USER -P $SA_PASSWORD -Q "SELECT 1" -b -o /dev/null

# Launch SQL Server, confirm startup is complete, deploy the DACPAC, then terminate SQL Server.
# See https://stackoverflow.com/a/51589787/488695
RUN ( /opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
    && /opt/sqlpackage/sqlpackage /a:Publish /tsn:. /tdn:${DBNAME} /tu:sa /tp:$SA_PASSWORD /sf:/tmp/db.dacpac \
    && rm /tmp/db.dacpac \
    && pkill sqlservr \
    && for FILE in ./SeedData/*; do /opt/mssql-tools/bin/sqlcmd -i $FILE -U $SA_USER -P $SA_PASSWORD; done