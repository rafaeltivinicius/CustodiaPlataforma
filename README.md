 # Plataforma de Custódia

- O projeto foi construída com .Net Core 3.1, API no padrão Rest, com Docker e sendo cacheada com Redis, separada nas camadas : API,  Service,  DTO e  Infra.  
- Cada produto tem seu próprio serviço e repositório, com chamadas assíncronas. A regra de negócio da posição consolidada encontra-se no service do mesmo.
- A aplicação está contenizada, caso execute pelo perfil Docker, apenas certifique-se que o Redis esteja rodando
- O Redis, foi criado uma instância na AWS e consumido pelo mesmo, os dados estão sendo inserido com o tempo de expiração de 24 horas
- Para os logs, foi tulizado a biblioteca do Serilog
