    <Page
        x:Class="Sample.TestTextBox"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:Sample"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
    
        <Page.Resources>
            <Style x:Key="ListViewStyle1" TargetType="ListView">
                <Setter Property="IsTabStop" Value="False"/>
                <Setter Property="TabNavigation" Value="Once"/>
                <Setter Property="IsSwipeEnabled" Value="True"/>
                <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
                <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
                <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled"/>
                <Setter Property="ScrollViewer.IsHorizontalRailEnabled" Value="False"/>
                <Setter Property="ScrollViewer.VerticalScrollMode" Value="Enabled"/>
                <Setter Property="ScrollViewer.IsVerticalRailEnabled" Value="True"/>
                <Setter Property="ScrollViewer.ZoomMode" Value="Disabled"/>
                <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
                <Setter Property="ScrollViewer.BringIntoViewOnFocusChange" Value="True"/>
                <Setter Property="ItemContainerTransitions">
                    <Setter.Value>
                        <TransitionCollection>
                            <AddDeleteThemeTransition/>
                            <ContentThemeTransition/>
                            <ReorderThemeTransition/>
                            <EntranceThemeTransition IsStaggeringEnabled="False"/>
                        </TransitionCollection>
                    </Setter.Value>
                </Setter>
                <Setter Property="ItemsPanel">
                    <Setter.Value>
                        <ItemsPanelTemplate>
                            <ItemsStackPanel Orientation="Vertical"/>
                        </ItemsPanelTemplate>
                    </Setter.Value>
                </Setter>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListView">
                            <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" >
                                <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}" IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" TabNavigation="{TemplateBinding TabNavigation}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                                    <ItemsPresenter FooterTransitions="{TemplateBinding FooterTransitions}" FooterTemplate="{TemplateBinding FooterTemplate}" Footer="{TemplateBinding Footer}" HeaderTemplate="{TemplateBinding HeaderTemplate}" Header="{TemplateBinding Header}" HeaderTransitions="{TemplateBinding HeaderTransitions}" Padding="{TemplateBinding Padding}" ManipulationMode="TranslateX, System"/>
                                </ScrollViewer>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Page.Resources>
    
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" ManipulationMode="TranslateX" ManipulationDelta="Grid_ManipulationDelta">
    
            <ListView Style="{StaticResource ListViewStyle1}">
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
                <ListViewItem>A</ListViewItem>
            </ListView>
    
        </Grid>
    </Page>
