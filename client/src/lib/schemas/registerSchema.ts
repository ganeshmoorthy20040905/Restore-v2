import z from "zod/v3";

const paswwordValidation = new RegExp(
    /(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/
)

export const  registerSchema = z.object({
    email:z.string().email(),
    password: z.string().regex(paswwordValidation,{
        message:'Password must contain 1 lowercase character,1 uppercase charcter, 1 number, 1 special and be 6-10 character'
   }),
      
});

export type RegisterSchema = z.infer<typeof registerSchema>;