CREATE TABLE IF NOT EXISTS public.flight_items
(
    id serial,
    site text,
	launchedAt timestamp,
    landedAt timestamp,
    distance smallint,
    notes text,
    PRIMARY KEY (id)
);


ALTER TABLE IF EXISTS public.flight_items
    OWNER to postgres;