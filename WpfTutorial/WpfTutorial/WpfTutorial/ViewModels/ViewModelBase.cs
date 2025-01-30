using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTutorial.ViewModels;

/**
 * INotifyPropertyChanged: 속성(Property)이 변경되었을 때 UI나 다른 시스템이 그 변경을 감지하고 적절히 반응하도록 설정
 */
public abstract class ViewModelBase : INotifyPropertyChanged
{
    /**
     * 속성이 변경되었음을 UI나 다른 클래스에 발생하는 이벤트입니다.
     * OnPropertyChanged 함수를 통해 Trigger됩니다.
     */
    public event PropertyChangedEventHandler? PropertyChanged;

    /**
     * [CallerMemberName]는 매개변수로 전달된 값을 생략할 때, 메서드를 호출한 속성의 이름을 자동으로 전달합니다.
     * CallerMemberName에 해당하는 속성이 변경되었음을 UI에 알리기 위한 함수입니다.
     */
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}