using PTL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PTL.Data.Repository.IRepository
{
    public interface ISP_Call
    {
        ServiceResponse<DataSet> TableList(ClassProAccessParams parm);

        #region Service Response 
        ServiceResponse<IEnumerable<T>> ListServiceResponse<T>(ClassProAccessParams parm);
        ServiceResponse<IEnumerable<T>> ListDataServiceResponse<T>(ClassProAccessParams parm);
        ServiceResponse<IEnumerable<T>> ListDataServiceResponseFr14<T>(ClassProAccessParams parm);
        ServiceResponse<IEnumerable<T>> ListDataServiceResponseFr20<T>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListServiceResponse<T1, T2>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListExecuteServiceResponse<T1, T2>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>>> ListExecuteServiceResponseFr14<T1, T2>(ClassProAccessParams parm);

        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListServiceResponse<T1, T2, T3>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListExecuteServiceResponse<T1, T2, T3>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> ListExecuteServiceResponseFr20<T1, T2, T3>(ClassProAccessParams parm);

        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> ListServiceResponse<T1, T2, T3, T4>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>> ListExecuteServiceResponse<T1, T2, T3, T4>(ClassProAccessParams parm);

        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>> ListServiceResponse<T1, T2, T3, T4, T5>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5>(ClassProAccessParams parm);


        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListServiceResponse<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>> ListExecuteServiceResponseFr14<T1, T2, T3, T4, T5, T6>(ClassProAccessParams parm);

        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>> ListServiceResponse<T1, T2, T3, T4, T5, T6, T7>(ClassProAccessParams parm);
        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>> ListExecuteServiceResponse<T1, T2, T3, T4, T5, T6, T7>(ClassProAccessParams parm);

        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>>>> ListExecuteServiceResponseFr9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ClassProAccessParams parm);


        ServiceResponse<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>>>> ListExecuteServiceResponseFr11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ClassProAccessParams parm);



        ServiceResponse<T> OneRecordServiceResponse<T>(ClassProAccessParams parm);

        ServiceResponse<bool> Execute40ServiceResponse(ClassProAccessParams parm);
        ServiceResponse<bool> Execute25ServiceResponse(ClassProAccessParams parm);
        ServiceResponse<bool> Execute22ServiceResponse(ClassProAccessParams parm);
        ServiceResponse<bool> Execute22ServiceResponse2(ClassProAccessParams parm);
        ServiceResponse<bool> Execute18ServiceResponse(ClassProAccessParams parm);
        ServiceResponse<bool> Execute14ServiceResponse(ClassProAccessParams parm, string conn = "");

        ServiceResponse<DataSet> TableListServiceResponse(ClassProAccessParams parm);


        #endregion
    }
}