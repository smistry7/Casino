from mcr.microsoft.com/mssql/server:2019-latest

workdir /src/.batect/sql-server

COPY ./Casino.Database.dacpac .

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
ARG DBNAME=Database
ARG PASSWORD=YourS3cureP@ass

# Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_USER="sa"
ENV SA_PASSWORD=$PASSWORD

# Launch SQL Server, confirm startup is complete, deploy the DACPAC, then terminate SQL Server.
# See https://stackoverflow.com/a/51589787/488695
RUN ( /opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
    && /opt/sqlpackage/sqlpackage /a:Publish /tsn:. /tdn:${DBNAME} /tu:sa /tp:$SA_PASSWORD /sf:/tmp/db.dacpac \
    && rm /tmp/db.dacpac \
    && pkill sqlservr