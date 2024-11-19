CREATE TABLE public."Country"
(
    id integer,
    name character varying(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE public."Department"
(
    id integer,
    name character varying(50) NOT NULL,
    country_id integer NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT country_fk FOREIGN KEY (country_id)
        REFERENCES public."Country" (id)
);

CREATE TABLE public."City"
(
    id integer,
    name character varying(50) NOT NULL,
    department_id integer,
    PRIMARY KEY (id),
    CONSTRAINT department_fk FOREIGN KEY (department_id)
        REFERENCES public."Department" (id)
);

CREATE TABLE public."User"
(
    id integer,
    name character varying(50) NOT NULL,
    address character varying(50) NOT NULL,
    phone character varying(20) NOT NULL,
    city_id integer,
    PRIMARY KEY (id),
    CONSTRAINT city_fk FOREIGN KEY (city_id)
        REFERENCES public."City" (id)
);

CREATE TABLE public."TokenUser"
(
    username character varying(20) NOT NULL,
    password character varying(20) NOT NULL,
    "isActive" boolean NOT NULL
)