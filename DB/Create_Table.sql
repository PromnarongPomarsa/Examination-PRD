CREATE TABLE public.tb_m_msg (
    id              BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    msg_code        VARCHAR(20), 
    msg_desc        VARCHAR(20),
    create_by    	VARCHAR(20),
    create_date     TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
);

CREATE TABLE public.tb_t_question (
    id              BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    question        VARCHAR(255), 
    answer_first    VARCHAR(50),
    answer_second	VARCHAR(50),
    answer_third	VARCHAR(50),
    answer_four		VARCHAR(50),
    create_by    	VARCHAR(20),
    create_date     TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);
