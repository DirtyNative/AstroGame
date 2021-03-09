import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';
import 'element_type.dart';

part 'element.g.dart';

@GuidConverter()
@JsonSerializable()
class Element extends Resource {
  @JsonKey()
  String symbol;

  @JsonKey()
  ElementType type;

  Element(
    Guid id,
    String name,
    int naturalOccurrenceWeight,
    List<StellarObjectResource> stellarObjectResources,
    this.symbol,
    this.type,
  ) : super(
          id,
          name,
          naturalOccurrenceWeight,
          stellarObjectResources,
        );

  factory Element.fromJson(Map<String, dynamic> json) =>
      _$ElementFromJson(json);
  Map<String, dynamic> toJson() => _$ElementToJson(this);
}
