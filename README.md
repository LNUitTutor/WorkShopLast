# Тривалі обчислення у фоновому потоці

Приклад використання **async/await**, **IProgress**, **Task**.
Десктопний застосунок _Windows Forms_ запускає фоновий потік, що імітує тривалі обчислення. Обчислення можна перервати та запустити повторно.
Хід виконання відображається компонентою _Progress_ і відповідними текстовими повідомленнями. Головна програма отримує з потоку результат обчислень.
