import { useRouter } from 'next/router';
import DetailForm from "../../../components/Tag/DetailForm";

export default function Page(){
    const Router = useRouter();
    
    return(
        <DetailForm tagId={Router.query.id} />
    )
}