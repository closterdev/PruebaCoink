CREATE OR REPLACE PROCEDURE public.sp_insert_user(
	IN name character varying, 
	IN phone character varying, 
	IN address character varying, 
	IN city_id integer
)
    LANGUAGE 'plpgsql'
    
AS $BODY$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM public."City" WHERE Id = city_id) THEN
        RAISE EXCEPTION 'El Municipio_Id % no existe', city_id;
    END IF;

	INSERT INTO public."User" (name, phone, address, city_id) 
	VALUES (name, phone, address, city_id);
END;
$BODY$;