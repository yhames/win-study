using System.Windows;
using System.Windows.Media;

namespace Kakao.Common.Extensions
{
    public static class FindParentExtension
    {
        public static T? FindParent<T>(this  DependencyObject child) where T : DependencyObject
        {
            return FindParent<T>(child, null);
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

            // parentName이 null일 경우, 이름을 체크하지 않고 해당 부모 요소를 반환합니다.
            if (parentName == null)
            {
                return (T)parent;
            }

            // 부모가 FrameworkElement인 경우, 이름을 확인하고 타입이 T인지 확인합니다.
            var frameworkElement = (FrameworkElement)parent;
            if (frameworkElement.Name == parentName && frameworkElement is T)
            {
                return (T)parent;
            }

            // 조건을 만족하지 않으면 부모 요소의 부모를 재귀적으로 탐색합니다.
            return FindParent<T>(parent, parentName);
        }
    }
}
