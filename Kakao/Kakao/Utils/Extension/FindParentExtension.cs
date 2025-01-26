using System.Windows;
using System.Windows.Media;

namespace Kakao.Utils.Extension
{
    public static class FindParentExtension
    {
        public static T? FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            return child.FindParent<T>(null);
        }

        public static T? FindParent<T>(this DependencyObject child, string? parentName) where T : DependencyObject
        {
            // 부모 요소를 찾습니다.
            var parent = VisualTreeHelper.GetParent(child);

            // 부모가 없으면 null을 반환합니다. (트리의 끝에 도달한 경우)
            if (parent == null)
            {
                return null;
            }

            // 부모가 FrameworkElement인 경우, 이름을 확인하고 타입이 T인지 확인합니다.
            var frameworkElement = (FrameworkElement)parent;
            if (isNameMatch(parent, parentName) && frameworkElement is T)
            {
                return (T)parent;
            }

            // 조건을 만족하지 않으면 부모 요소의 부모를 재귀적으로 탐색합니다.
            return FindParent<T>(parent, parentName);
        }

        private static bool isNameMatch(DependencyObject parent, string? parentName)
        {
            if (parentName == null)
            {
                return true;
            }
            var frameworkElement = (FrameworkElement)parent;
            return frameworkElement.Name == parentName;
        }
    }
}
