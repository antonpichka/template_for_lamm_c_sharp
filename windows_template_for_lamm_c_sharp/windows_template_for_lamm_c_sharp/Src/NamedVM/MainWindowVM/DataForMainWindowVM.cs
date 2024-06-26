using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public sealed class DataForMainWindowVM(bool isLoading) : BaseDataForNamed<EnumDataForMainWindowVM>(isLoading)
{
    public override EnumDataForMainWindowVM GetEnumDataForNamed()
    {
        if(isLoading) 
        {
            return EnumDataForMainWindowVM.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return EnumDataForMainWindowVM.exception;
        }
        return EnumDataForMainWindowVM.success;
    }

    public override string ToString()
    {
        return $"DataForMainWindowVM(isLoading: {isLoading}, exceptionController: {exceptionController})";
    }
}
