using library_architecture_mvvm_modify_c_sharp;

namespace windows_template_for_lamm_c_sharp;

public sealed class DataForExampleWindowVM(bool isLoading) : BaseDataForNamed<EnumDataForExampleWindowVM>(isLoading)
{
    public override EnumDataForExampleWindowVM GetEnumDataForNamed()
    {
        if(isLoading) 
        {
            return EnumDataForExampleWindowVM.isLoading;
        }
        if(exceptionController.IsWhereNotEqualsNullParameterException()) 
        {
            return EnumDataForExampleWindowVM.exception;
        }
        return EnumDataForExampleWindowVM.success;
    }

    public override string ToString()
    {
        return $"DataForExampleWindowVM(isLoading: {isLoading}, exceptionController: {exceptionController})";
    }
}
