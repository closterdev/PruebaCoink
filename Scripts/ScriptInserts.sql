INSERT INTO public."TokenUser"(
	username, password, "isActive")
	VALUES ('test', 'dGVzdA==', true);


INSERT INTO public."Country"(
	name)
	VALUES ('Colombia');


INSERT INTO public."Department"(
	name, country_id)
	VALUES ('Cundinamarca', 1);


INSERT INTO public."City"(
	name, department_id)
	VALUES ('Chia', 1);