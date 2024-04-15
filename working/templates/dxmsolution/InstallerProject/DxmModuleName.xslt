<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:wix="http://wixtoolset.org/schemas/v4/wxs"
    xmlns="http://wixtoolset.org/schemas/v4/wxs"
  exclude-result-prefixes="wix">

	<xsl:output method="xml" encoding="UTF-8" indent="yes" />

	<xsl:template match="wix:Component[child::wix:File[substring( @Source, string-length( @Source ) - 3 ) = '.exe']]" />
	<xsl:key name="ExeComponentsToSuppress" match="wix:Component[child::wix:File[substring( @Source, string-length( @Source ) - 3 ) = '.exe']]" use="@Id" />
	<xsl:template match="wix:ComponentRef[key('ExeComponentsToSuppress', @Id)]" />

	<xsl:template match="wix:Component[child::wix:File[substring( @Source, string-length( @Source ) - 3 ) = '.pdb']]" />
	<xsl:key name="PdbComponentsToSuppress" match="wix:Component[child::wix:File[substring( @Source, string-length( @Source ) - 3 ) = '.pdb']]" use="@Id" />
	<xsl:template match="wix:ComponentRef[key('PdbComponentsToSuppress', @Id)]" />

	<xsl:key name="SubDirComponentKeys" match="/wix:Wix/wix:Fragment/wix:DirectoryRef/wix:Directory/wix:Directory//wix:Component" use="@Id" />
	<xsl:template match="/wix:Wix/wix:Fragment/wix:DirectoryRef/wix:Directory/wix:Directory" />
	<xsl:template match="//wix:ComponentRef[contains(key('SubDirComponentKeys',@Id)/wix:File/@Source, '\')]" />

	<!-- ### Adding the Win64-attribute to all Components -->
	<xsl:template match="wix:Component">
		<xsl:copy>
			<xsl:apply-templates select="@*" />
			<!-- Adding the Win64-attribute as we have a x64 application -->
			<xsl:attribute name="Bitness">always64</xsl:attribute>

			<!-- Now take the rest of the inner tag -->
			<xsl:apply-templates select="node()" />
		</xsl:copy>
	</xsl:template>

	<xsl:template match="@*|node()">
		<xsl:copy>
			<xsl:apply-templates select="@*|node()" />
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>