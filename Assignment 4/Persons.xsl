<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:template match="/">
      <html>
        <head>
            <link rel="stylesheet" type="text/css" href="./Persons.css"/>
        </head>
        <body>
          <h1>Assignment 4 - Justin Lucker</h1>
          <table>
            <tr width="900px">
              <th width ="250px" colspan="2">Name</th>
              <th width ="350px" colspan="3">Credential</th>
              <th width ="300px" colspan="3">Phone</th>
              <th width ="100px" colspan="1">Category</th>
            </tr>
            <tr>
              <th width ="100px">First Name</th>
              <th width ="100px">Last Name </th>
              <th width ="100px">ID</th>
              <th width ="100px">Password</th>
              <th width ="150px">Encryption (yes/no)</th>
              <th width ="100px">Work</th>
              <th width ="100px">Cell</th>
              <th width ="100px">Provider</th>
              <th width ="100px">Friend/Family/Work</th>
            </tr>
            <xsl:for-each select="Persons/Person">
            <tr>
              <td><xsl:value-of select="Name/First"/></td>
              <td><xsl:value-of select="Name/Last"/></td>
              <td><xsl:value-of select="Credential/Id"/></td>
              <td><xsl:value-of select="Credential/Password/PasswordValue"/></td>
              <td><xsl:value-of select="Credential/Password/@Encryption"/></td>
              <td><xsl:value-of select="Phone/Work"/></td>
              <td><xsl:value-of select="Phone/Cell/CellNumber"/></td>
              <td><xsl:value-of select="Phone/Cell/@Provider"/></td>
              <td><xsl:value-of select="Category/@CategoryValue"/></td>
            </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
