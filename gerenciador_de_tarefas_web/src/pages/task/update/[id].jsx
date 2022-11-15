import { useRouter } from 'next/router';
import DetailForm from "../../../components/Task/DetailForm";

export default function Page(){
    const Router = useRouter();
    
    return(
        <DetailForm taskId={Router.query.id} />
    )
}