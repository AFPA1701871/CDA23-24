CREATE TABLE public."order" (
    id integer NOT NULL,
    supplier_id integer,
    date date DEFAULT CURRENT_DATE NOT NULL,
    comments character varying(800)
);


--
-- TOC entry 3419 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN "order".comments; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public."order".comments IS 'Commentaires concernant la commande.';


--
-- TOC entry 217 (class 1259 OID 25964)
-- Name: entcom_numcom_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.entcom_numcom_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3420 (class 0 OID 0)
-- Dependencies: 217
-- Name: entcom_numcom_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.entcom_numcom_seq OWNED BY public."order".id;


--
-- TOC entry 216 (class 1259 OID 25957)
-- Name: supplier; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.supplier (
    id integer NOT NULL,
    name character varying(30),
    address character varying(30),
    postal_code character varying(5),
    city character varying(25),
    contact_name character varying(15),
    satisfaction_index integer DEFAULT NULL::numeric
);


--
-- TOC entry 215 (class 1259 OID 25956)
-- Name: fournis_numfou_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.fournis_numfou_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3421 (class 0 OID 0)
-- Dependencies: 215
-- Name: fournis_numfou_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.fournis_numfou_seq OWNED BY public.supplier.id;


--
-- TOC entry 220 (class 1259 OID 25978)
-- Name: item; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.item (
    id integer NOT NULL,
    item_code character(4) NOT NULL,
    name character varying(25),
    stock_alert integer NOT NULL,
    stock integer NOT NULL,
    yearly_consumption integer NOT NULL,
    unit character varying(15)
);


--
-- TOC entry 3422 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN item.yearly_consumption; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.item.yearly_consumption IS 'Consommation annuelle estimée.';


--
-- TOC entry 222 (class 1259 OID 25985)
-- Name: order_line; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.order_line (
    order_id integer NOT NULL,
    item_id integer NOT NULL,
    line_number numeric(3,0) NOT NULL,
    ordered_quantity integer NOT NULL,
    unit_price double precision NOT NULL,
    delivered_quantity numeric(6,0) DEFAULT NULL::numeric,
    last_delivery_date date
);


--
-- TOC entry 3423 (class 0 OID 0)
-- Dependencies: 222
-- Name: COLUMN order_line.line_number; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.order_line.line_number IS 'Numéro de la ligne de commande.';


--
-- TOC entry 3424 (class 0 OID 0)
-- Dependencies: 222
-- Name: COLUMN order_line.ordered_quantity; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.order_line.ordered_quantity IS 'Le nombre d''articles commandés.';


--
-- TOC entry 221 (class 1259 OID 25984)
-- Name: ligcom_numcom_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.ligcom_numcom_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3425 (class 0 OID 0)
-- Dependencies: 221
-- Name: ligcom_numcom_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.ligcom_numcom_seq OWNED BY public.order_line.order_id;


--
-- TOC entry 219 (class 1259 OID 25977)
-- Name: produit_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.produit_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3426 (class 0 OID 0)
-- Dependencies: 219
-- Name: produit_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.produit_id_seq OWNED BY public.item.id;


--
-- TOC entry 223 (class 1259 OID 26002)
-- Name: sale_offer; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.sale_offer (
    item_id integer NOT NULL,
    supplier_id integer NOT NULL,
    delivery_time numeric(6,0) NOT NULL,
    price integer NOT NULL,
    date date
);


--
-- TOC entry 3427 (class 0 OID 0)
-- Dependencies: 223
-- Name: COLUMN sale_offer.delivery_time; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.sale_offer.delivery_time IS 'Délait de livraison estimé par le fournisseur.';


--
-- TOC entry 3428 (class 0 OID 0)
-- Dependencies: 223
-- Name: COLUMN sale_offer.price; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.sale_offer.price IS 'Prix unitaire pour le produit.';


--
-- TOC entry 3429 (class 0 OID 0)
-- Dependencies: 223
-- Name: COLUMN sale_offer.date; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.sale_offer.date IS 'Date de l''offre.';


--
-- TOC entry 3244 (class 2604 OID 25981)
-- Name: item id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.item ALTER COLUMN id SET DEFAULT nextval('public.produit_id_seq'::regclass);


--
-- TOC entry 3242 (class 2604 OID 25968)
-- Name: order id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."order" ALTER COLUMN id SET DEFAULT nextval('public.entcom_numcom_seq'::regclass);


--
-- TOC entry 3245 (class 2604 OID 25988)
-- Name: order_line order_id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.order_line ALTER COLUMN order_id SET DEFAULT nextval('public.ligcom_numcom_seq'::regclass);


--
-- TOC entry 3240 (class 2604 OID 25960)
-- Name: supplier id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.supplier ALTER COLUMN id SET DEFAULT nextval('public.fournis_numfou_seq'::regclass);


--
-- TOC entry 3410 (class 0 OID 25978)
-- Dependencies: 220
-- Data for Name: item; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.item VALUES (0, 'B001', 'Bande magnetique 1200', 20, 87, 240, 'unite');
INSERT INTO public.item VALUES (1, 'B002', 'Bande magnétique 6250', 20, 12, 410, 'unite');
INSERT INTO public.item VALUES (2, 'D035', 'CD R slim 80 mm', 40, 42, 150, 'B010');
INSERT INTO public.item VALUES (3, 'D050', 'CD R-W 80mm', 50, 4, 0, 'B010');
INSERT INTO public.item VALUES (4, 'I100', 'Papier 1 ex continu', 100, 557, 3500, 'B1000');
INSERT INTO public.item VALUES (5, 'I105', 'Papier 2 ex continu', 75, 5, 2300, 'B1000');
INSERT INTO public.item VALUES (6, 'I108', 'Papier 3 ex continu', 200, 557, 3500, 'B500');
INSERT INTO public.item VALUES (7, 'I110', 'Papier 4 ex continu', 10, 12, 63, 'B400');
INSERT INTO public.item VALUES (8, 'P220', 'Pre-imprime commande', 500, 2500, 24500, 'B500');
INSERT INTO public.item VALUES (9, 'P230', 'Pre-imprime facture', 500, 250, 12500, 'B500');
INSERT INTO public.item VALUES (10, 'P240', 'Pre-imprime bulletin paie', 500, 3000, 6250, 'B500');
INSERT INTO public.item VALUES (11, 'P250', 'Pre-imprime bon livraison', 500, 2500, 24500, 'B500');
INSERT INTO public.item VALUES (12, 'P270', 'Pre-imprime bon fabricati', 500, 2500, 24500, 'B500');
INSERT INTO public.item VALUES (13, 'R080', 'ruban Epson 850', 10, 2, 120, 'unite');
INSERT INTO public.item VALUES (14, '14  ', 'ruban impl 1200 lignes', 25, 200, 182, 'unite');


--
-- TOC entry 3408 (class 0 OID 25965)
-- Dependencies: 218
-- Data for Name: order; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."order" VALUES (70010, 120, '2021-01-15', NULL);
INSERT INTO public."order" VALUES (70011, 540, '2021-01-15', 'Commande urgente');
INSERT INTO public."order" VALUES (70020, 9180, '2021-01-15', NULL);
INSERT INTO public."order" VALUES (70025, 9150, '2021-01-15', 'Commande urgente');
INSERT INTO public."order" VALUES (70210, 120, '2021-01-15', 'Commande cadencée');
INSERT INTO public."order" VALUES (70250, 8700, '2021-01-15', 'Commande cadencée');
INSERT INTO public."order" VALUES (70300, 9120, '2021-01-15', NULL);
INSERT INTO public."order" VALUES (70620, 540, '2021-01-15', NULL);
INSERT INTO public."order" VALUES (70625, 120, '2021-01-15', NULL);
INSERT INTO public."order" VALUES (70629, 9180, '2021-01-15', NULL);


--
-- TOC entry 3412 (class 0 OID 25985)
-- Dependencies: 222
-- Data for Name: order_line; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.order_line VALUES (70010, 4, 1, 3000, 470, 3000, '2021-01-15');
INSERT INTO public.order_line VALUES (70010, 5, 2, 2000, 485, 2000, '2021-01-15');
INSERT INTO public.order_line VALUES (70010, 6, 3, 1000, 680, 1000, '2021-01-15');
INSERT INTO public.order_line VALUES (70010, 8, 5, 6000, 999.99, 6000, '2021-01-15');
INSERT INTO public.order_line VALUES (70010, 10, 6, 6000, 999.99, 2000, '2021-01-15');
INSERT INTO public.order_line VALUES (70010, 13, 2, 10000, 999.99, 10000, '2021-01-15');
INSERT INTO public.order_line VALUES (70011, 5, 1, 1000, 600, 1000, '2021-01-15');
INSERT INTO public.order_line VALUES (70020, 0, 1, 200, 140, NULL, NULL);
INSERT INTO public.order_line VALUES (70020, 1, 2, 200, 140, NULL, NULL);
INSERT INTO public.order_line VALUES (70025, 4, 1, 1000, 590, 1000, '2021-01-15');
INSERT INTO public.order_line VALUES (70025, 5, 2, 500, 590, 500, '2021-01-15');
INSERT INTO public.order_line VALUES (70210, 4, 1, 1000, 470, 1000, '2021-01-15');
INSERT INTO public.order_line VALUES (70250, 8, 2, 10000, 999.99, 10000, '2021-01-15');
INSERT INTO public.order_line VALUES (70250, 9, 1, 15000, 999.99, 12000, '2021-01-15');
INSERT INTO public.order_line VALUES (70300, 7, 1, 50, 790, 50, '2021-01-15');
INSERT INTO public.order_line VALUES (70620, 5, 1, 200, 600, 200, '2021-01-15');
INSERT INTO public.order_line VALUES (70625, 4, 1, 1000, 470, 1000, '2021-01-15');
INSERT INTO public.order_line VALUES (70625, 8, 2, 10000, 999.99, 10000, '2021-01-15');
INSERT INTO public.order_line VALUES (70629, 0, 1, 200, 140, NULL, NULL);
INSERT INTO public.order_line VALUES (70629, 1, 2, 200, 140, NULL, NULL);
INSERT INTO public.order_line VALUES (70010, 2, 4, 200, 40, 200, '2021-01-15');


--
-- TOC entry 3413 (class 0 OID 26002)
-- Dependencies: 223
-- Data for Name: sale_offer; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.sale_offer VALUES (0, 8700, 15, 150, NULL);
INSERT INTO public.sale_offer VALUES (1, 8700, 15, 210, NULL);
INSERT INTO public.sale_offer VALUES (2, 120, 0, 40, NULL);
INSERT INTO public.sale_offer VALUES (2, 9120, 5, 40, NULL);
INSERT INTO public.sale_offer VALUES (4, 120, 90, 700, NULL);
INSERT INTO public.sale_offer VALUES (4, 540, 70, 710, NULL);
INSERT INTO public.sale_offer VALUES (4, 9120, 60, 800, NULL);
INSERT INTO public.sale_offer VALUES (4, 9150, 90, 650, NULL);
INSERT INTO public.sale_offer VALUES (4, 9180, 30, 720, NULL);
INSERT INTO public.sale_offer VALUES (5, 120, 90, 705, NULL);
INSERT INTO public.sale_offer VALUES (5, 540, 70, 810, NULL);
INSERT INTO public.sale_offer VALUES (5, 8700, 30, 720, NULL);
INSERT INTO public.sale_offer VALUES (5, 9120, 60, 920, NULL);
INSERT INTO public.sale_offer VALUES (5, 9150, 90, 685, NULL);
INSERT INTO public.sale_offer VALUES (6, 120, 90, 795, NULL);
INSERT INTO public.sale_offer VALUES (6, 9120, 60, 920, NULL);
INSERT INTO public.sale_offer VALUES (7, 9120, 60, 950, NULL);
INSERT INTO public.sale_offer VALUES (7, 9180, 90, 900, NULL);
INSERT INTO public.sale_offer VALUES (13, 9120, 10, 120, NULL);
INSERT INTO public.sale_offer VALUES (14, 9120, 5, 275, NULL);


--
-- TOC entry 3406 (class 0 OID 25957)
-- Dependencies: 216
-- Data for Name: supplier; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public.supplier VALUES (120, 'GROBRIGAN', '20 rue du papier', '92200', 'papercity', 'georges', 8);
INSERT INTO public.supplier VALUES (540, 'ECLIPSE', '53 rue laisse flotter', '78250', 'bugbugville', 'nestor', 7);
INSERT INTO public.supplier VALUES (8700, 'MEDICIS', '120 rue des plantes', '75014', 'paris', 'lison', NULL);
INSERT INTO public.supplier VALUES (9120, 'DICOBOL', '11 rue des sports', '85100', 'roche/yon', 'hercule', 8);
INSERT INTO public.supplier VALUES (9150, 'DEPANPAP', '26 av des loco', '59987', 'coroncountry', 'pollux', 5);
INSERT INTO public.supplier VALUES (9180, 'HURRYTAPE', '68 bvd des octets', '04044', 'Dumpville', 'Track', NULL);
INSERT INTO public.supplier VALUES (1, 'TEST', '10 rue du test', '17000', 'La Rochelle', 'DUfont', 3);


--
-- TOC entry 3430 (class 0 OID 0)
-- Dependencies: 217
-- Name: entcom_numcom_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.entcom_numcom_seq', 1, false);


--
-- TOC entry 3431 (class 0 OID 0)
-- Dependencies: 215
-- Name: fournis_numfou_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.fournis_numfou_seq', 9, true);


--
-- TOC entry 3432 (class 0 OID 0)
-- Dependencies: 221
-- Name: ligcom_numcom_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.ligcom_numcom_seq', 1, false);


--
-- TOC entry 3433 (class 0 OID 0)
-- Dependencies: 219
-- Name: produit_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.produit_id_seq', 1, false);


--
-- TOC entry 3252 (class 2606 OID 25983)
-- Name: item item_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.item
    ADD CONSTRAINT item_pkey PRIMARY KEY (id);


--
-- TOC entry 3254 (class 2606 OID 25991)
-- Name: order_line order_line_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.order_line
    ADD CONSTRAINT order_line_pkey PRIMARY KEY (order_id, item_id);


--
-- TOC entry 3250 (class 2606 OID 25971)
-- Name: order order_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT order_pkey PRIMARY KEY (id);


--
-- TOC entry 3256 (class 2606 OID 26006)
-- Name: sale_offer sale_offer_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sale_offer
    ADD CONSTRAINT sale_offer_pkey PRIMARY KEY (item_id, supplier_id);


--
-- TOC entry 3248 (class 2606 OID 25963)
-- Name: supplier supplier_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.supplier
    ADD CONSTRAINT supplier_pkey PRIMARY KEY (id);



--
-- TOC entry 3258 (class 2606 OID 25992)
-- Name: order_line fk_ligcom_entcom; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.order_line
    ADD CONSTRAINT fk_ligcom_entcom FOREIGN KEY (order_id) REFERENCES public."order"(id) ON DELETE CASCADE;


--
-- TOC entry 3259 (class 2606 OID 25997)
-- Name: order_line fk_ligcom_produit; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.order_line
    ADD CONSTRAINT fk_ligcom_produit FOREIGN KEY (item_id) REFERENCES public.item(id);


--
-- TOC entry 3257 (class 2606 OID 41008)
-- Name: order fk_order_supplier; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."order"
    ADD CONSTRAINT fk_order_supplier FOREIGN KEY (supplier_id) REFERENCES public.supplier(id) ON DELETE SET NULL;


--
-- TOC entry 3260 (class 2606 OID 26007)
-- Name: sale_offer supplier_ibfk_1; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sale_offer
    ADD CONSTRAINT supplier_ibfk_1 FOREIGN KEY (supplier_id) REFERENCES public.supplier(id);


--
-- TOC entry 3261 (class 2606 OID 26012)
-- Name: sale_offer supplier_ibfk_2; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sale_offer
    ADD CONSTRAINT supplier_ibfk_2 FOREIGN KEY (item_id) REFERENCES public.item(id);


-- Completed on 2023-04-06 06:03:24

--
-- PostgreSQL database dump complete
--

